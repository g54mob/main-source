using UnityEngine;

namespace TH20
{
	public class Racoon
	{
		public RoomItem Bin;

		[DontSave]
		private GameObject _instance;

		[DontSave]
		private Animator[] _animators;

		public void Setup(GameObject prefab)
		{
			_instance = Object.Instantiate(prefab, Bin.WorldPosition, Quaternion.Euler(0f, Random.Range(0, 360), 0f));
			_animators = _instance.GetComponentsInChildren<Animator>();
		}

		public void Destroy()
		{
			Object.Destroy(_instance);
		}

		public bool Update()
		{
			bool result = true;
			Animator[] animators = _animators;
			for (int i = 0; i < animators.Length; i++)
			{
				if (animators[i].GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
				{
					result = false;
				}
			}
			return result;
		}
	}
}
