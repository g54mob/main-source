using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly]
	public class RoomItemAnimEventMaterialSwapComponent : EntityTickComponent
	{
		private bool[] _set;

		[DontSave]
		private RoomItemAnimEventMaterialSwap[] _components;

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			RoomItem owner = GetOwner<RoomItem>();
			if (owner.Visual != null)
			{
				OnVisualSet();
			}
			owner.OnVisualSet += OnVisualSet;
		}

		public override void Destroy()
		{
			GetOwner<RoomItem>().OnVisualSet -= OnVisualSet;
			UnregisterComponents();
			base.Destroy();
		}

		private void UnregisterComponents()
		{
			if (!_components.IsEmpty())
			{
				RoomItemAnimEventMaterialSwap[] components = _components;
				for (int i = 0; i < components.Length; i++)
				{
					components[i].Unregister();
				}
				_components = null;
			}
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			RoomItem owner = GetOwner<RoomItem>();
			owner.OnVisualSet += OnVisualSet;
			if (owner.Visual != null)
			{
				OnVisualSet();
			}
		}

		private void OnVisualSet()
		{
			RoomItem owner = GetOwner<RoomItem>();
			if (owner.Visual != null && owner.Visual.GameObject != null)
			{
				_components = owner.Visual.GameObject.GetComponentsInChildren<RoomItemAnimEventMaterialSwap>();
				if (_components.IsEmpty())
				{
					return;
				}
				if (_set == null || _set.Length < _components.Length)
				{
					_set = new bool[_components.Length];
				}
				for (int i = 0; i < _components.Length; i++)
				{
					RoomItemAnimEventMaterialSwap roomItemAnimEventMaterialSwap = _components[i];
					roomItemAnimEventMaterialSwap.RoomItemVisual = owner.Visual;
					roomItemAnimEventMaterialSwap.Register();
					if (_set[i])
					{
						roomItemAnimEventMaterialSwap.SetMaterials();
					}
				}
			}
			else
			{
				UnregisterComponents();
			}
		}

		public override void Tick()
		{
			base.Tick();
			if (!_components.IsEmpty())
			{
				for (int i = 0; i < _components.Length; i++)
				{
					RoomItemAnimEventMaterialSwap roomItemAnimEventMaterialSwap = _components[i];
					_set[i] = roomItemAnimEventMaterialSwap.Set;
				}
			}
		}
	}
}
