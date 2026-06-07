public readonly struct SceneLoaded
{
	public readonly string Scene;

	public bool IsMainMenu => Scene == "MainMenu";

	public bool IsGame => Scene == "GameScene";

	public SceneLoaded(string scene)
	{
		Scene = scene;
	}
}
