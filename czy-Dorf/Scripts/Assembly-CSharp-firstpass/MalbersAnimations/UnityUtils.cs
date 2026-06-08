using UnityEngine;

namespace MalbersAnimations
{
	public class UnityUtils : MonoBehaviour
	{
		public virtual void Freeze_Time(bool value)
		{
			Time.timeScale = ((!value) ? 1 : 0);
		}

		public void DestroyMe(float time)
		{
			Object.Destroy(base.gameObject, time);
		}

		public void DestroyMe()
		{
			Object.Destroy(base.gameObject);
		}

		public void GameObjectHide(float time)
		{
			Invoke("GOHide", time);
		}

		private void GOHide()
		{
			base.gameObject.SetActive(value: false);
		}

		public void DestroyGameObject(GameObject go)
		{
			Object.Destroy(go);
		}

		public void RandomRotateAroundX()
		{
			base.transform.Rotate(new Vector3(Random.Range(0, 360), 0f, 0f), Space.Self);
		}

		public void RandomRotateAroundY()
		{
			base.transform.Rotate(new Vector3(0f, Random.Range(0, 360), 0f), Space.Self);
		}

		public void RandomRotateAroundZ()
		{
			base.transform.Rotate(new Vector3(0f, 0f, Random.Range(0, 360)), Space.Self);
		}

		public void DestroyComponent(Component component)
		{
			Object.Destroy(component);
		}

		public void Parent(Transform newParent)
		{
			base.transform.parent = newParent;
		}

		public void Parent_Local(Transform newParent)
		{
			base.transform.parent = newParent;
			base.transform.localPosition = Vector3.zero;
			base.transform.localRotation = Quaternion.identity;
			base.transform.localScale = Vector3.one;
		}

		public void Instantiate(GameObject go)
		{
			Object.Instantiate(go, base.transform.position, base.transform.rotation);
		}

		public void InstantiateAndParent(GameObject go)
		{
			Object.Instantiate(go, base.transform.position, base.transform.rotation, base.transform);
		}

		public static void ShowCursor(bool value)
		{
			Cursor.lockState = ((!value) ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = value;
		}
	}
}
