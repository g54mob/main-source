using Items;
using UnityEngine;

namespace ComplexItems.Generator
{
	[RequireComponent(typeof(Collider))]
	public class WirePicker : MonoBehaviour, IUsable
	{
		[SerializeField]
		private WireController _wireController;

		private MaleWire _maleWire;

		private bool _wireVisible;

		private void Awake()
		{
			_maleWire = _wireController.GetComponentInChildren<MaleWire>();
		}

		private void Start()
		{
			SetWireVisible();
		}

		void IUsable.UnUse()
		{
		}

		void IUsable.Use()
		{
			_wireVisible = !_wireVisible;
			SetWireVisible();
		}

		private void SetWireVisible()
		{
			_wireController.gameObject.SetActive(_wireVisible);
			if (_maleWire.ConnectedConsumer != null)
			{
				if (_wireVisible)
				{
					_maleWire.OnConnected?.Invoke(_maleWire.ConnectedConsumer);
					return;
				}
				_maleWire.OnDisconnected?.Invoke(_maleWire.ConnectedConsumer);
				_maleWire.ConnectedPlug.OnUnplagged();
			}
		}
	}
}
