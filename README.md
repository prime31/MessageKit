MessageKit
==========

Decoupled message sending system meant as a replacement for SendMessage and its variants. MessageKit comes with the ability to send zero, one or two parameter messages. The keys for messages are ints. Most message systems use strings but it has been my experience that folks are less likely to define their keys as consts when dealing with strings so it ends up creating hard to debug issues when a string is mistyped. By using ints for keys the hope is that MessageKit users will define their keys as *const ints* so that they get the benefit of code completion and end up with easy to read code.



Usage
---

- define your event types as *const ints*
- to add an event listener for a zero parameter event call *MessageKit.addObserver( eventType, handler )*
- post events by calling *MessageKit.post( eventType )*
- don't forget to remove your event listeners with *MessageKit.removeObserver( handler )*!


One or Two Parameter Events
---

When using events with parameters you need to specifiy the paramter types so that everything remains strongly typed.

- to add an event listener for a one parameter event call *MessageKit&lt;Transform&gt;.addObserver( eventType, handler )* (notice that the parameter type is Transform for this example)
- post events by calling *MessageKit&lt;Transform&gt;.post( eventType, someTransform )*
- don't forget to remove your event listeners with *MessageKit&lt;Transform&gt;.removeObserver( handler )*!


License
-----

[Attribution-NonCommercial-ShareAlike 3.0 Unported](http://creativecommons.org/licenses/by-nc-sa/3.0/legalcode) with [simple explanation](http://creativecommons.org/licenses/by-nc-sa/3.0/deed.en_US) with the attribution clause waived. You are free to use MessageKit in any and all games that you make. You cannot sell MessageKit directly or as part of a larger game asset.
