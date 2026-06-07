public class SceneController : Controller
{
	public SceneManager sceneManager;

	public Workbench workbench { get; private set; }

	public Playroom playroom { get; private set; }

	public override void Init()
	{
	}
}
