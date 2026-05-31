public interface ISaveObject
{
	string MyID { get; }

	object SaveData();

	void LoadData(object dataIn);
}
