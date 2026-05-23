public interface ISaveLoad
{
	void OnBeforeMainLoadPass(string guid);

	void OnLoad(string guid);

	void OnAfterMainLoadPass(string guid);

	void OnSave(string guid);
}
