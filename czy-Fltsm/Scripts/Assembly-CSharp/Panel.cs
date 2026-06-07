using FMODUnity;
using I2.Loc;
using PajamaLlama.Utilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public abstract class Panel : MonoBehaviour, IPanel
{
	[Header("Panel")]
	[SerializeField]
	private PanelID _id = PanelID.None;

	[SerializeField]
	private LocalizedString _titleString = null;

	[Header("FMOD")]
	[SerializeField]
	private EventReference _FMODEventReference_Open;

	[SerializeField]
	private EventReference _FMODEventReference_Close;

	[Header("Events")]
	[SerializeField]
	[FormerlySerializedAs("OnClose")]
	private UnityEvent _onClose;

	public virtual PanelID ID => _id;

	public virtual LocalizedString Title => _titleString;

	public void ClickClose()
	{
		Close();
	}

	public virtual void Initialize()
	{
	}

	public virtual bool Open(PanelID id, IPanelContext context = null)
	{
		if (_id == id)
		{
			OnOpen(context);
			FinalUpdate.RegisterEndOfFrameOneShot(DispatchPanelOpenEvent);
			AudioManager.PlayOneShot(_FMODEventReference_Open);
			base.gameObject.SetActive(value: true);
			OnOpened(context);
			return true;
		}
		return false;
	}

	protected virtual void OnOpen(IPanelContext context)
	{
	}

	protected virtual void OnOpened(IPanelContext context)
	{
	}

	public bool IsOpen()
	{
		return base.gameObject.activeSelf;
	}

	public virtual void OnContainerStateChanged(PanelContainerState state)
	{
	}

	public virtual void Close()
	{
		OnClose();
		_onClose.Invoke();
		AudioManager.PlayOneShot(_FMODEventReference_Close);
		FinalUpdate.RegisterEndOfFrameOneShot(DispatchPanelClosedEvent);
		base.gameObject.SetActive(value: false);
	}

	protected virtual void OnClose()
	{
	}

	private void DispatchPanelOpenEvent()
	{
		PanelEvent.DispatchPanelOpenedEvent(this);
	}

	private void DispatchPanelClosedEvent()
	{
		PanelEvent.DispatchPanelClosedEvent(this);
	}

	public virtual bool CanBeOpened(PanelID id, IPanelContext context = null)
	{
		return _id == id;
	}
}
