using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	public class BreakableStructureScript : BreakableObjectScript
	{
		private GameObject _damagedState;

		[SerializeField]
		private float _damageStateTimer;

		[SerializeField]
		private GameObject _destroyedPrefab;

		[SerializeField]
		private GameObject _normalState;

		[SerializeField]
		private float _rubbleDelay;

		[SerializeField]
		private GameObject _rubblePrefab;

		private GameObject _rubbleState;

		protected override void OnBroken(bool initialValue)
		{
			base.OnBroken(initialValue);
			if (!initialValue && _destroyedPrefab != null)
			{
				_damagedState = Object.Instantiate(_destroyedPrefab);
				_damagedState.transform.SetParent(_normalState.transform.parent, worldPositionStays: false);
				if (_damageStateTimer > 0f)
				{
					Object.Destroy(_damagedState, _damageStateTimer);
				}
			}
			if (_rubblePrefab != null)
			{
				StartCoroutine(CreateRubble(initialValue ? 0f : _rubbleDelay));
			}
			_normalState.SetActive(value: false);
		}

		protected override void OnHealed()
		{
			base.OnHealed();
			if (_damagedState != null)
			{
				Object.Destroy(_damagedState);
				_damagedState = null;
			}
			if (_rubbleState != null)
			{
				Object.Destroy(_rubbleState);
				_rubbleState = null;
			}
			_normalState.SetActive(value: true);
		}

		protected override void Start()
		{
			base.Start();
			if (_normalState != null && _normalState.transform.parent == null)
			{
				Debug.LogWarning("The '" + base.gameObject.name + "' normalState field has a null parent, which indicates it might be a prefab which is not supported. The normalState field should be referencing a game object in the scene.", base.gameObject);
			}
		}

		private IEnumerator CreateRubble(float seconds)
		{
			yield return new WaitForSeconds(seconds);
			_rubbleState = Object.Instantiate(_rubblePrefab);
			_rubbleState.transform.SetParent(_normalState.transform.parent, worldPositionStays: false);
		}
	}
}
