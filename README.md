MessageKit
==========

Decoupled message sending system meant as a replacement for SendMessage and its variants. MessageKit comes with the ability to send zero, one or two paramter messages. The keys for messages are ints. Most message systems use strings but it has been my experience that folks are less likely to define their keys as consts when dealing with strings so it ends up creating hard to debug issues when a string is mistyped. By using ints for keys the hope is that MessageKit users will define their keys as *const ints* so that they get the benefit of code completion and end up with easy to read code.



Usage
---

- define your event types as *const ints*
- to add an event listener for a zero parameter event call *MessageKit.addObserver( eventType, handler )*
- post events by calling *MessageKit.post( eventType )*
- don't forget to remove your event listeners with *MessageKit.removeObserver( handler )*!


One or Two Parameter Events
---

When using events with parameters you need to specifiy the paramter types so that everything remains strongly typed.

- to add an event listener for a one parameter event call *MessageKit<Transform>.addObserver( eventType, handler )* (notice that the parameter type is Transform for this example)
- post events by calling *MessageKit<Transform>.post( eventType, someTransform )*
- don't forget to remove your event listeners with *MessageKit.removeObserver( handler )*!