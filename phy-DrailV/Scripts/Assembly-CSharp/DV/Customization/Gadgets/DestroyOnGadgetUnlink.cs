using UnityEngine;

namespace DV.Customization.Gadgets
{
	[RequireComponent(typeof(GadgetBase))]
	public class DestroyOnGadgetUnlink : MonoBehaviour
	{
		public GameObject replacement;

		public bool instantiate = true;

		private GadgetBase gadget;

		private void Awake()
		{
			gadget = GetComponent<GadgetBase>();
			gadget.AfterUnlinked += OnUnlinked;
		}

		private void OnUnlinked(Customization.CustomizerBase customizer, Customization customization)
		{
			Vector3 position = base.transform.position;
			Quaternion rotation = base.transform.rotation;
			Object.Destroy(gadget.GadgetItem.gameObject);
			if (instantiate)
			{
				Object.Instantiate(replacement, position, rotation);
				return;
			}
			replacement.transform.position = position;
			replacement.transform.rotation = rotation;
			replacement.SetActive(value: true);
		}

		public void Disable()
		{
			if ((bool)gadget)
			{
				gadget.AfterUnlinked -= OnUnlinked;
			}
		}
	}
}
