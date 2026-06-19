using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class JellyFish : EntityMonoBehaviour
{
	public GameObject body;

	public SpriteObject indirectLightEmitter;

	private const float MIN_HEIGHT = -3.3f;

	private const float MAX_HEIGHT = -0.5f;

	private const float HALF_HEIGHT_MOVEMENT_SPAN = 0.5f;

	private const float HEIGHT_MOVE_SPEED = 0.15f;

	private TimerSimple heightMovementTimer;

	private float newHeight;

	private float prevHeight;

	private float startHeight;

	private Color m_emissiveColor;

	private Color m_indirectColor;

	protected override void Awake()
	{
		base.Awake();
		m_emissiveColor = spriteObjects[0].emissiveColor;
		m_indirectColor = indirectLightEmitter.emissiveColor;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		startHeight = UnityEngine.Random.Range(-2.8f, -1f);
		body.transform.localPosition = new Vector3(0f, startHeight, 0f);
		newHeight = startHeight;
		prevHeight = startHeight;
		heightMovementTimer.Stop();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (!heightMovementTimer.isRunning || heightMovementTimer.isTimerElapsed)
		{
			SetNewTargetHeight();
		}
		body.transform.localPosition = new Vector3(0f, math.lerp(prevHeight, newHeight, heightMovementTimer.elapsedRatio), 0f);
		float num = 1f - Mathf.Clamp01((0f - body.transform.localPosition.y) / 3f);
		spriteObjects[0].emissiveColor = m_emissiveColor * num;
		indirectLightEmitter.emissiveColor = m_indirectColor * num;
		indirectLightEmitter.transform.localScale = Vector3.one * Mathf.Max(Mathf.Epsilon, num) * 3f;
	}

	private void SetNewTargetHeight()
	{
		prevHeight = newHeight;
		newHeight = UnityEngine.Random.Range(startHeight - 0.5f, startHeight + 0.5f);
		float num;
		for (num = math.distance(newHeight, prevHeight); num < 0.005f; num = math.distance(newHeight, prevHeight))
		{
			newHeight = UnityEngine.Random.Range(startHeight - 0.5f, startHeight + 0.5f);
		}
		heightMovementTimer.Start(num / 0.15f);
	}
}
