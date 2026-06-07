using DG.Tweening;
using UnityEngine;
using UnityEngine.U2D;

public class Cable : MonoBehaviour
{
	public SpriteShapeController cable;

	public CableConnector connector;

	public int centralPoints;

	public Vector3 offset;

	public float disconnectedDistance;

	public float fadeInAndConnectDelay;

	public float disconnectAndFadeOutDelay;

	public Holder.TransitionDurations fadeTransitionDuration;

	public Ease fadeEase;

	public Holder.TransitionDurations connectTransitionDuration;

	public Ease connectEase;

	private bool isFadedIn;

	private bool isConnected;

	private Sequence tween;

	private Coroutine delay;

	public bool IsConnected()
	{
		return false;
	}

	public bool IsFadedIn()
	{
		return false;
	}

	public bool IsMoving()
	{
		return false;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
	{
		return default(Vector3);
	}

	public void FadeIn(float fadeDelay = 0f)
	{
	}

	public void FadeOut(float fadeDelay = 0f)
	{
	}

	public void Connect(float connectDelay = 0f)
	{
	}

	public void Disconnect(float disconnectDelay = 0f)
	{
	}

	private void OnDisconnectComplete()
	{
	}
}
