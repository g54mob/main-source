using System.Threading.Tasks;
using UnityEngine;

namespace Motorways.UI.EditMenu
{
	public class EditMenuControllerWidget : MonoBehaviour
	{
		public void Open()
		{
			base.gameObject.SetActive(value: true);
		}

		public void Close()
		{
			base.gameObject.SetActive(value: false);
		}

		public void TurnToFace(Vector3 position, bool animate = true)
		{
			Vector3 vector = position - base.transform.position;
			float num = Mathf.Atan2(vector.y, vector.x) * 57.29578f - 90f;
			if (animate)
			{
				AnimateToRotation(num);
			}
			else
			{
				base.transform.rotation = Quaternion.Euler(0f, 0f, num);
			}
		}

		private async Task AnimateToRotation(float angle)
		{
			float duration = 0.15f;
			float startAngle = base.transform.rotation.eulerAngles.z;
			float elapsedTime = 0f;
			while (elapsedTime < duration)
			{
				elapsedTime += Time.deltaTime;
				float num = Mathf.Clamp01(elapsedTime / duration);
				num = num * num * (3f - 2f * num);
				float z = Mathf.LerpAngle(startAngle, angle, num);
				base.transform.rotation = Quaternion.Euler(0f, 0f, z);
				await Task.Yield();
			}
		}
	}
}
