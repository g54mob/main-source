using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Animal Controller/Dragon Egg")]
	public class DragonEgg : MonoBehaviour
	{
		public enum HatchType
		{
			None = 0,
			Input = 1,
			Time = 2
		}

		protected Animator anim;

		protected MAnimal animal;

		public Vector3 preHatchOffset;

		public GameObject Dragon;

		public float removeShells = 10f;

		private bool crack_egg;

		[HideInInspector]
		public InputRow input = new InputRow("CrackEgg", KeyCode.Alpha0, InputButton.Down);

		[HideInInspector]
		public float seconds;

		public HatchType hatchtype;

		public UnityEvent OnEggCrack = new UnityEvent();

		private void Awake()
		{
			anim = GetComponent<Animator>();
		}

		private void Start()
		{
			base.gameObject.SetActive(value: true);
			anim.Rebind();
			anim.Update(0f);
			if (!Dragon)
			{
				return;
			}
			if (Dragon.IsPrefab())
			{
				Dragon = Object.Instantiate(Dragon);
			}
			animal = Dragon.GetComponent<MAnimal>();
			if ((bool)animal)
			{
				animal.transform.position = base.transform.position;
				animal.Anim.Play("Hatch");
				animal.LockInput = true;
				animal.LockMovement = true;
				animal.EnableColliders(active: false);
				animal.transform.localPosition += preHatchOffset;
			}
			Renderer[] componentsInChildren = Dragon.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
			}
			if (hatchtype == HatchType.Time)
			{
				this.Delay_Action(seconds, delegate
				{
					CrackEgg();
				});
			}
		}

		public void SetDragon(GameObject newDragon)
		{
			Dragon = newDragon;
			Start();
		}

		private void Update()
		{
			if (hatchtype == HatchType.Input && input.GetValue)
			{
				crack_egg = true;
			}
			if (crack_egg)
			{
				CrackEgg();
			}
		}

		public void CrackEgg()
		{
			Collider component = GetComponent<Collider>();
			anim.SetInteger("State", 1);
			if ((bool)component)
			{
				Object.Destroy(component);
			}
			if ((bool)animal)
			{
				animal.State_Force(StateEnum.Idle);
				animal.EnableColliders(active: true);
				Renderer[] componentsInChildren = animal.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].enabled = true;
				}
				animal.SetModeStatus(Random.Range(1, 4));
			}
			OnEggCrack.Invoke();
			StartCoroutine(EggDisapear(removeShells));
		}

		private void EnableAnimalScript()
		{
			if ((bool)animal)
			{
				animal.enabled = true;
			}
		}

		private IEnumerator EggDisapear(float seconds)
		{
			yield return null;
			if (seconds > 0f)
			{
				if ((bool)Dragon)
				{
					Dragon.transform.position = base.transform.position;
				}
				yield return new WaitForSeconds(seconds);
				anim.SetInteger("State", 2);
				yield return new WaitForSeconds(1f);
				base.gameObject.SetActive(value: false);
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
