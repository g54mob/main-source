using MoreMountains.Feedbacks;
using UnityEngine;

public class FlipperPuzzle_Tile : MonoBehaviour
{
	public enum TileState
	{
		idle = 0,
		flipped = 1
	}

	public int tileValue;

	private FlipperPuzzleManager flipperPuzzleManager;

	public TileState tileState;

	private Quaternion flipTarget_Rot;

	private const float flipSpeed = 600f;

	public bool tileSolved;

	[SerializeField]
	private MMF_Player feedback_Success;

	[SerializeField]
	private MMF_Player feedback_Failed;

	private void Start()
	{
		flipTarget_Rot = Quaternion.Euler(180f, 0f, 0f);
	}

	private void Update()
	{
		if (GameManager.Singleton.gameState == GameManager.GameState.Playing && tileState == TileState.flipped)
		{
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, flipTarget_Rot, Time.deltaTime * 600f);
		}
	}

	public void SetOurManager(FlipperPuzzleManager _manager)
	{
		flipperPuzzleManager = _manager;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (GameManager.Singleton.gameState != GameManager.GameState.Playing || flipperPuzzleManager.puzzleState != FlipperPuzzleManager.FlipperPuzzleState.Active || tileState != TileState.idle || !collision.collider.transform.root.gameObject.CompareTag("PickUp"))
		{
			return;
		}
		PickUppable component = collision.collider.transform.root.gameObject.GetComponent<PickUppable>();
		if (!(component == null) && component.recentlyThrown)
		{
			GameObject gameObject = collision.collider.transform.root.gameObject;
			if ((bool)gameObject.GetComponent<Berry>())
			{
				flipperPuzzleManager.FlipATile(this);
				Object.Destroy(gameObject);
			}
		}
	}

	public void PlayFeedback_Success()
	{
		feedback_Success?.PlayFeedbacks();
	}

	public void PlayFeedback_Failed()
	{
		feedback_Failed?.PlayFeedbacks();
	}
}
