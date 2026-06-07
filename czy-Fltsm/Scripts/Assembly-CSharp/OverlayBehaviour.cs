using UnityEngine;
using UnityEngine.PajamaLlama;

public class OverlayBehaviour : MonoBehaviour
{
	private enum Modes
	{
		Single = 0,
		Multiple = 1
	}

	[SerializeField]
	[ConditionalEnumHide("_mode", 0, false, HideInInspector = true)]
	private Overlays.Type _overlay;

	[SerializeField]
	[ConditionalEnumHide("_mode", 1, false, HideInInspector = true)]
	[NamedArrayElement(new string[] { "" })]
	private Overlays.Type[] _overlays;

	protected virtual void Awake()
	{
		OnOverlayUpdated();
		GameEventDispatcher.AddListener(GameEventType.OverlayUpdate, OnOverlayUpdated);
	}

	protected virtual void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.OverlayUpdate, OnOverlayUpdated);
	}

	private void OnOverlayUpdated(GameEvent gameEvent = null)
	{
		base.gameObject.SetActive(HasActiveOverlay());
	}

	public bool HasActiveOverlay()
	{
		if (_overlays.IsNullOrEmpty())
		{
			return _overlay == Overlays.OverlayType;
		}
		Overlays.Type[] overlays = _overlays;
		for (int i = 0; i < overlays.Length; i++)
		{
			if (overlays[i] == Overlays.OverlayType)
			{
				return true;
			}
		}
		return false;
	}
}
