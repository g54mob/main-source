using UnityEngine;

namespace DV.Customization
{
	public abstract class SingletonCustomization<T> : Customization where T : SingletonCustomization<T>
	{
		private static T i;

		public static T I
		{
			get
			{
				if (i == null)
				{
					GameObject obj = new GameObject("[" + typeof(T).Name + "]");
					obj.transform.rotation = Quaternion.identity;
					obj.transform.localScale = Vector3.one;
					i = obj.AddComponent<T>();
					obj.AddComponent<Rigidbody>().isKinematic = true;
				}
				return i;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			if (i != null)
			{
				Debug.LogError("[CUSTOMIZATION] Singleton instance of T is already present! Cannot assign manually created instance.");
			}
			else
			{
				i = this as T;
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (i == this)
			{
				i = null;
			}
		}
	}
}
