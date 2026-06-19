using System;

[Serializable]
public class SaveableGutFlora
{
	public string path;

	public SerializableVector3 localScale;

	public SerializableVector3 localPosition;

	public bool boosted;

	public SaveableGutFlora(GutFloraBase floraRef)
	{
		SaveFlora(floraRef);
	}

	private SaveableGutFlora()
	{
	}

	public SaveableGutFlora GetCopy()
	{
		return new SaveableGutFlora
		{
			path = path,
			localScale = localScale.GetCopy(),
			localPosition = localPosition.GetCopy(),
			boosted = boosted
		};
	}

	public void SaveFlora(GutFloraBase floraRef)
	{
		path = floraRef.GetFloraPath();
		localScale = new SerializableVector3(floraRef.transform.localScale);
		localPosition = new SerializableVector3(floraRef.rigidbodyRef.transform.localPosition);
		boosted = floraRef.IsBoosted();
	}
}
