using System;

public delegate void UnregisterCallback<E>(EventHandler<E> eventHandler) where E : EventArgs;
