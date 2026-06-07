public abstract class GnormanActionData : ScriptableData<GnormanAction>
{
	protected override string LocalizationPrefix => string.Empty;

	protected override LocTable LocalizationTable => LocTable.Gnorman;

	public abstract int MaxLines { get; }

	public abstract GnormanFluffActionLine Line(int index);

	public static implicit operator GnormanAction(GnormanActionData data)
	{
		return data.ID;
	}

	public static implicit operator GnormanActionData(GnormanAction node)
	{
		return node.Data();
	}
}
