using UnityEngine;

[RequireComponent(typeof(PugText))]
public abstract class PugTextEffect : MonoBehaviour, IPugTextEffect
{
	[SerializeField]
	private PugText _text;

	protected PugText text
	{
		get
		{
			if (!(_text == null))
			{
				return GetComponent<PugText>();
			}
			return _text;
		}
	}

	protected virtual void Awake()
	{
		_text = GetComponent<PugText>();
	}

	public virtual void ResetEffect(bool rewind)
	{
	}

	public abstract void PugTextEffectLateUpdate();
}
