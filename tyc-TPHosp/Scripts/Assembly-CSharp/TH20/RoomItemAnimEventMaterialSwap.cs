using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly]
	public class RoomItemAnimEventMaterialSwap : MonoBehaviour
	{
		[SerializeField]
		private AnimationEventListener _animationEventListener;

		[SerializeField]
		private Renderer _mesh;

		[SerializeField]
		private Material[] _materials;

		[SerializeField]
		private RoomItemVisual _roomItemVisual;

		private Material[] _savedMaterials;

		public bool Set { get; private set; }

		public RoomItemVisual RoomItemVisual
		{
			get
			{
				return _roomItemVisual;
			}
			set
			{
				_roomItemVisual = value;
			}
		}

		public void Register()
		{
			_animationEventListener.RegisterEvent("SetMaterials", SetMaterials);
			_animationEventListener.RegisterEvent("RestoreMaterials", RestoreMaterials);
		}

		public void Unregister()
		{
			_animationEventListener.UnregisterEvent("SetMaterials", SetMaterials);
			_animationEventListener.UnregisterEvent("RestoreMaterials", RestoreMaterials);
		}

		public void SetMaterials()
		{
			if (!Set)
			{
				Set = true;
				_savedMaterials = _roomItemVisual.GetOriginalMaterials(_mesh);
				_mesh.sharedMaterials = _materials;
				if (_roomItemVisual != null)
				{
					_roomItemVisual.UpdateOriginalMaterials(_mesh, _mesh.sharedMaterials);
				}
			}
		}

		private void SetMaterials(AnimationEvent animationEvent)
		{
			SetMaterials();
		}

		private void RestoreMaterials(AnimationEvent animationEvent)
		{
			if (Set)
			{
				Set = false;
				_mesh.sharedMaterials = _savedMaterials;
				_savedMaterials = null;
				if (_roomItemVisual != null)
				{
					_roomItemVisual.UpdateOriginalMaterials(_mesh, _mesh.sharedMaterials);
				}
			}
		}
	}
}
