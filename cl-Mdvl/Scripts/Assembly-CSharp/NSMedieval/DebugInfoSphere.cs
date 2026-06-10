using System;
using NSMedieval.Tools;
using TMPro;
using UnityEngine;

namespace NSMedieval
{
	public class DebugInfoSphere : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer sphere;

		[SerializeField]
		private TMP_Text text;

		private int raycastMask;

		private Color color;

		public event Action<bool> OnHoverEvent;

		public void SetColor(Color color)
		{
			this.color = color;
			sphere.material.color = this.color;
		}

		public void SetText(string text)
		{
			this.text.SetText(text);
		}

		public void SetSphereScale(float scale)
		{
			sphere.transform.localScale = new Vector3(scale, scale, scale);
		}

		private void Start()
		{
			raycastMask = 1 << LayerMask.NameToLayer("Default");
			text.gameObject.SetActive(value: false);
		}

		private void Update()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = default(RaycastHit);
			if (!RaycastUtils.RaycastToSurface(out hit, ray, raycastMask))
			{
				return;
			}
			if (hit.transform != sphere.transform)
			{
				if (text.gameObject.activeSelf)
				{
					this.OnHoverEvent?.Invoke(obj: false);
				}
				sphere.material.color = color;
				text.gameObject.SetActive(value: false);
			}
			else if (!text.gameObject.activeSelf)
			{
				text.gameObject.SetActive(value: true);
				this.OnHoverEvent?.Invoke(obj: true);
				Color white = Color.white;
				white.a = 0.3f;
				sphere.material.color = white;
			}
		}
	}
}
