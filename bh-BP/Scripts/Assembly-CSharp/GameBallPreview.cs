using Shapes;
using UnityEngine;
using UnityEngine.UI;

public class GameBallPreview : BallPreview
{
	public new static GameBallPreview I;

	public GameObject WrapperDefaultPreview;

	public Canvas CvsReload;

	public Image ReloadFill;

	public BallPreview AltPreview;

	public LineRenderer GravityPreview;

	public LineRenderer AltGravityPreview;

	private const float kMaxPostBounceDist = 2f;

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	public void Init()
	{
	}

	public override void SetInputEnabled(bool isEnabled)
	{
	}

	protected override void MyUpdate()
	{
	}

	public override void SetColor(Color c)
	{
	}

	private void OnBallStateChanged()
	{
	}

	private void OnCurBallChanged()
	{
	}

	private void SetGravityAimDir(Vector3 pos, Vector3 aimDir, Polyline gravityPreview, bool isGravity)
	{
	}

	private void SetGravityAimDir(int charIdx, Vector3 pos, Vector3 aimDir, LineRenderer gravityPreview, bool isGravity)
	{
	}

	public override void SetAimDir(Vector3 pos, Vector2 aimDir, int firstBounceMask = -9999, int secondBounceMask = -9999)
	{
	}
}
