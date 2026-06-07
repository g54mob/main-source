using System.Collections.Generic;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12CasingConveyor : MonoBehaviour
	{
		[SerializeField]
		private T3PowerSwitch _lever;

		[SerializeField]
		private T12CasingPlate _platePrefab;

		[SerializeField]
		private float _moveSpeed;

		[SerializeField]
		private float _spawnInterval = 3f;

		[SerializeField]
		private Vector2 _spawnPoint;

		[SerializeField]
		private float _despawnX;

		[SerializeField]
		private float _stampMinX;

		[SerializeField]
		private float _stampMaxX;

		private List<T12CasingPlate> _plates = new List<T12CasingPlate>();

		private float _moveDistance = 99f;

		private ActiveWorldFrame _parent;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		private void Update()
		{
			if (!(_lever.Progress > 0.95f))
			{
				return;
			}
			float num = Time.deltaTime * _moveSpeed;
			for (int i = 0; i < _plates.Count; i++)
			{
				T12CasingPlate t12CasingPlate = _plates[i];
				t12CasingPlate.transform.localPosition = t12CasingPlate.transform.localPosition + new Vector3(num, 0f, 0f);
				if (t12CasingPlate.transform.localPosition.x > _despawnX)
				{
					Object.Destroy(t12CasingPlate.gameObject);
					_plates.RemoveAt(i);
					i--;
				}
			}
			_moveDistance += num;
			if (_moveDistance > _spawnInterval)
			{
				T12CasingPlate t12CasingPlate2 = Object.Instantiate(_platePrefab, base.transform);
				t12CasingPlate2.transform.localPosition = _spawnPoint;
				_plates.Add(t12CasingPlate2);
				_moveDistance = 0f;
			}
		}

		public void Stamp(float stampX)
		{
			foreach (T12CasingPlate plate in _plates)
			{
				float x = plate.transform.localPosition.x;
				if (!plate.Stamped && x >= _stampMinX && x <= _stampMaxX)
				{
					plate.Stamp(stampX);
					UISounds.CraftStep();
					_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
					return;
				}
			}
			_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "@T12OmegaProjectCasingWarning");
		}
	}
}
