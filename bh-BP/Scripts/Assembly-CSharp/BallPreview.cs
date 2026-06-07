using MEC;
using Shapes;
using UnityEngine;

public class BallPreview : MonoBehaviour
{
	public static BallPreview I;

	public Line StartLine;

	public Line BounceLine;

	protected Vector2 _aimDir;

	public Color CurColor;

	protected bool _isEnabled;

	protected float _t;

	protected CoroutineHandle _colorAnim;

	protected virtual void Awake()
	{
	}

	public virtual void SetInputEnabled(bool isEnabled)
	{
	}

	public bool IsInputEnabled()
	{
		return false;
	}

	public void SetAlpha(float alpha)
	{
	}

	public virtual void SetColor(Color c)
	{
	}

	protected virtual void MyUpdate()
	{
	}

	public virtual void SetAimDir(Vector3 pos, Vector2 aimDir, int firstBounceMask = -9999, int secondBounceMask = -9999)
	{
	}

	private RaycastHit2D GetRCHit(Vector3 startPos, Vector2 aimDir, CharMetaInst worker)
	{
		return default(RaycastHit2D);
	}

	public void SetAimDirWorker(Vector3 pos, Vector2 aimDir, CharMetaInst worker)
	{
	}

	public Vector2 GetAimDir()
	{
		return default(Vector2);
	}
}
