using BoardEditor;

public class CommonEvents
{
	public delegate void MDownOnObjectEventHandler(IGEObject geobject, int tileX, int tileY);

	public delegate void MUpOnObjectEventHandler(IGEObject geobject);

	public delegate void ObjectMEnterEventHandler(IGEObject geobject);

	public delegate void ObjectActivateChangedEventHandler(IGEObject geobject, bool isNowActive);
}
