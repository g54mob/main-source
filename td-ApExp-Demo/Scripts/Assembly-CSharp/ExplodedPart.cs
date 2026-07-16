using UnityEngine;

public class ExplodedPart : MonoBehaviour
{
	private Vector3 randomDir;

	[SerializeField]
	private float timeBeforeShrink;

	[SerializeField]
	private float rotSpeed;

	private float timeOnGround;

	private float timeAfterShrinkTimer;

	private Rigidbody2D rb2d;

	private float scaleDownPercent = 0.5f;

	private void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
		randomDir = new Vector3(0f, 0f, Random.Range(-1f, 1f));
	}

	private void Update()
	{
		base.transform.position += new Vector3(-1f, 0f) * Train.Instance.TrainSpeedNormalized * Time.deltaTime;
		if ((base.transform.position.x <= -2f && LevelManager.Instance.CurrentLevel.LevelType != LevelType.Boss) || LevelManager.Instance.IsAtDestination)
		{
			Object.Destroy(base.gameObject);
		}
		if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "Z3_Viaduct")
		{
			scaleDownPercent = 0f;
		}
		if (base.transform.localScale.x <= scaleDownPercent)
		{
			GetComponent<ParticleSystem>().Stop();
			timeOnGround = Mathf.Clamp01(timeOnGround + Time.deltaTime);
			Vector3 vector = new Vector3((0f - Train.Instance.SpeedCurrent) * Time.deltaTime, 0f);
			base.transform.position += vector * timeOnGround;
			return;
		}
		base.transform.Rotate(randomDir * rotSpeed * Time.deltaTime);
		if (!(rb2d.velocity.magnitude > 0.5f))
		{
			timeAfterShrinkTimer = Mathf.Clamp01(timeAfterShrinkTimer + Time.deltaTime);
			base.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * scaleDownPercent, timeAfterShrinkTimer);
		}
	}
}
