using System;
using Cpp2ILInjected;
using UnityEngine;

public class PhaserGameObject : GameMonoBehaviour, ArcadeColliderType
{
	public BaseBody body;

	private PhaserScene _scene;

	private bool _visible;

	private bool _ignoreDestroy;

	[NonSerialized]
	public PhaserContainer _parentContainer;

	public virtual bool isParent => false;

	public virtual bool isTilemap => false;

	BaseBody ArcadeColliderType.body => body;

	public virtual Rect? frame
	{
		get
		{
			//IL_0009: Expected O, but got I4
			PhaserGameObject phaserGameObject = (PhaserGameObject)0;
			((UnityEngine.Object)this).m_CachedPtr = (IntPtr)0;
			return (Rect?)this;
		}
	}

	public bool active
	{
		get
		{
			GameObject gameObject = base.gameObject;
			bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 45 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}
		set
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value);
		}
	}

	GameObject ArcadeColliderType.gameObject => base.gameObject;

	public virtual SpriteRenderer GetAttachedRenderer()
	{
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			SpriteRenderer result = default(SpriteRenderer);
			if (gameObject.TryGetComponent<SpriteRenderer>(out var component) || ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0))
			{
				return result;
			}
			GameObject gameObject2 = base.gameObject;
			if ((object)gameObject2 != null)
			{
				return gameObject2.GetComponentInChildren<SpriteRenderer>(includeInactive: false);
			}
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	protected override void OnDestroy()
	{
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._gameObject = null;
		}
	}

	public PhaserGameObject()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
