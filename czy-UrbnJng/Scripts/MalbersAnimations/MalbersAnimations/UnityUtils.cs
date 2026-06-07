using System.Collections;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Tools/Unity [Tools] Utilities")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/global-components/ui/unity-utils")]
	public class UnityUtils : MonoBehaviour
	{
		private AudioSource[] audios;

		public virtual void PauseEditor()
		{
			Debug.Log("Pause Editor", this);
			Debug.Break();
		}

		public virtual void Scale_By_Float(float scale)
		{
			base.transform.localScale = Vector3.one * scale;
		}

		public virtual void PauseAllAudio(bool pause)
		{
			if (!base.enabled)
			{
				return;
			}
			if (audios == null)
			{
				audios = Object.FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
			}
			AudioSource[] array;
			if (pause)
			{
				array = audios;
				foreach (AudioSource audioSource in array)
				{
					if (audioSource.isPlaying)
					{
						audioSource.Pause();
					}
				}
				return;
			}
			array = audios;
			foreach (AudioSource audioSource2 in array)
			{
				if (audioSource2 != null)
				{
					audioSource2.UnPause();
				}
			}
		}

		public void AddRigiBody()
		{
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			rigidbody.isKinematic = true;
		}

		public void DestroyRigidbody()
		{
			if (base.gameObject.TryGetComponent<Rigidbody>(out var component))
			{
				Object.Destroy(component);
			}
		}

		public void Forward_Direction(Transform target)
		{
			base.transform.forward = (target.position - base.transform.position).normalized;
		}

		public void Forward_Direction(TransformVar target)
		{
			Forward_Direction(target.Value);
		}

		public void Forward_Direction_NoY(Transform target)
		{
			Vector3 vector = target.position - base.transform.position;
			vector.y = 0f;
			base.transform.forward = vector.normalized;
		}

		public void Forward_Direction_NoY(TransformVar target)
		{
			Forward_Direction_NoY(target.Value);
		}

		public virtual void Toggle_Enable(Behaviour component)
		{
			component.enabled = !component.enabled;
		}

		public virtual void Time_Freeze(bool value)
		{
			Time_Scale((!value) ? 1 : 0);
		}

		public virtual void Time_Scale(float value)
		{
			Time.timeScale = value;
		}

		public virtual void Freeze_Time(bool value)
		{
			Time_Freeze(value);
		}

		public void DestroyMe(float time)
		{
			Object.Destroy(base.gameObject, time);
		}

		public void DestroyMe()
		{
			Object.Destroy(base.gameObject);
		}

		public void DestroyMeNextFrame()
		{
			StartCoroutine(DestroyNextFrame());
		}

		public void DestroyGameObject(GameObject go)
		{
			Object.Destroy(go);
		}

		public void DestroyComponent(Component component)
		{
			Object.Destroy(component);
		}

		public void Reset_GameObject(GameObject go)
		{
			go.SetActive(value: false);
			this.Delay_Action(delegate
			{
				go.SetActive(value: true);
			});
		}

		public void Reset_Monobehaviour(MonoBehaviour go)
		{
			go.SetEnable(enable: false);
			this.Delay_Action(delegate
			{
				go.SetEnable(enable: true);
			});
		}

		public void GameObjectHide(float time)
		{
			Invoke("DisableGo", time);
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

		public void DebugLog(string value)
		{
			Debug.Log("[" + base.name + "]-[" + value + "]", this);
		}

		public void DebugLog(object value)
		{
			Debug.Log($"[{base.name}]-[{value}]", this);
		}

		public void QuitGame()
		{
			Application.Quit();
		}

		public void Rotation_Reset()
		{
			base.transform.localRotation = Quaternion.identity;
		}

		public void Position_Reset()
		{
			base.transform.localPosition = Vector3.zero;
		}

		public void Rotation_Reset(GameObject go)
		{
			go.transform.localRotation = Quaternion.identity;
		}

		public void Position_Reset(GameObject go)
		{
			go.transform.localPosition = Vector3.zero;
		}

		public void Rotation_Reset(Transform go)
		{
			go.localRotation = Quaternion.identity;
		}

		public void Position_Reset(Transform go)
		{
			go.localPosition = Vector3.zero;
		}

		public void Parent(Transform value)
		{
			base.transform.parent = value;
		}

		public void Parent(GameObject value)
		{
			Parent(value.transform);
		}

		public void Parent(Component value)
		{
			Parent(value.transform);
		}

		public void Unparent(Transform value)
		{
			value.parent = null;
		}

		public void Unparent(GameObject value)
		{
			Unparent(value.transform);
		}

		public void Unparent(Component value)
		{
			Unparent(value.transform);
		}

		public void Behaviour_Disable(int index)
		{
			Behaviour[] components = GetComponents<Behaviour>();
			if (components != null)
			{
				components[index % components.Length].enabled = false;
			}
		}

		public void Behaviour_Enable(int index)
		{
			Behaviour[] components = GetComponents<Behaviour>();
			if (components != null)
			{
				components[index % components.Length].enabled = true;
			}
		}

		public void Behaviour_EnableNextFrame(Behaviour behaviour)
		{
			behaviour.enabled = false;
			this.Delay_Action(delegate
			{
				behaviour.enabled = true;
			});
		}

		public void Dont_Destroy_On_Load(GameObject value)
		{
			Object.DontDestroyOnLoad(value);
		}

		public void Load_Scene_Additive(string value)
		{
			SceneManager.LoadScene(value, LoadSceneMode.Additive);
		}

		public void Load_Scene(string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				SceneManager.LoadScene(value, LoadSceneMode.Single);
			}
		}

		public void Parent_Local(Transform value)
		{
			base.transform.parent = value;
			base.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			base.transform.localScale = Vector3.one;
		}

		public void Parent_Local(GameObject value)
		{
			Parent_Local(value.transform);
		}

		public void Parent_Local(Component value)
		{
			Parent_Local(value.transform);
		}

		public void Instantiate(GameObject value)
		{
			Object.Instantiate(value, base.transform.position, base.transform.rotation);
		}

		public void InstantiateAndParent(GameObject value)
		{
			Object.Instantiate(value, base.transform.position, base.transform.rotation, base.transform);
		}

		public static void ShowCursor(bool value)
		{
			Cursor.lockState = ((!value) ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = value;
		}

		public static void ShowCursorInvert(bool value)
		{
			ShowCursor(!value);
		}

		private void DisableGo()
		{
			base.gameObject.SetActive(value: false);
		}

		private IEnumerator C_Reset_GameObject(GameObject go)
		{
			if (go.activeInHierarchy)
			{
				go.SetActive(value: false);
				yield return null;
				go.SetActive(value: true);
			}
			yield return null;
		}

		private IEnumerator C_Reset_Mono(MonoBehaviour go)
		{
			if (go.gameObject.activeInHierarchy)
			{
				go.enabled = false;
				yield return null;
				go.enabled = true;
			}
			yield return null;
		}

		private IEnumerator DestroyNextFrame()
		{
			yield return null;
			Object.Destroy(base.gameObject);
		}

		public void RectTransform_Width(float width)
		{
			RectTransform component = GetComponent<RectTransform>();
			if ((bool)component)
			{
				component.sizeDelta = new Vector2(width, component.sizeDelta.y);
			}
		}

		public void RectTransform_Height(float height)
		{
			RectTransform component = GetComponent<RectTransform>();
			if ((bool)component)
			{
				component.sizeDelta = new Vector2(component.sizeDelta.x, height);
			}
		}

		public void RectTransform_Width(int width)
		{
			RectTransform_Width((float)width);
		}

		public void RectTransform_Height(int height)
		{
			RectTransform_Height((float)height);
		}
	}
}
