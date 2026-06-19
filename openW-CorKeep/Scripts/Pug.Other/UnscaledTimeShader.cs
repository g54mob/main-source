using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[ExecuteInEditMode]
public class UnscaledTimeShader : MonoBehaviour
{
	public string timeVariable = "myTime";

	private SpriteRenderer _spriteRenderer;

	private MaterialPropertyBlock mpb;

	private int timeVariableID;

	private float time;

	[Tooltip("Reduces accumulator errors when the game has been running for a long time")]
	public bool startFromZeroOnEnable = true;

	private void Awake()
	{
		timeVariableID = Shader.PropertyToID(timeVariable);
		_spriteRenderer = GetComponent<SpriteRenderer>();
		mpb = new MaterialPropertyBlock();
		GetMPB();
	}

	private void GetMPB()
	{
		_spriteRenderer.GetPropertyBlock(mpb);
	}

	private void SetMPB()
	{
		_spriteRenderer.SetPropertyBlock(mpb);
	}

	private void OnEnable()
	{
		if (startFromZeroOnEnable)
		{
			time = 0f;
		}
		else
		{
			time = Time.unscaledTime + 9000000f;
		}
	}

	private void LateUpdate()
	{
		time += Time.unscaledDeltaTime;
		mpb.SetFloat(timeVariableID, time);
		SetMPB();
	}
}
