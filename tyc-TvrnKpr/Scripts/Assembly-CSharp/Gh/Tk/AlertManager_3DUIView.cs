using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class AlertManager_3DUIView : MonoBehaviour
	{
		private GameObject _alertPrefab;

		public float minAlertSpacing;

		public float maxAlertSpacing;

		public Vector3 queueFrontPosition;

		public Vector3 queueBackPosition;

		private Dictionary<string, AlertVisualType> _alertVisualType;

		private List<Alert_3DUIView> _activeAlerts;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void ResetAlerts()
		{
		}

		private void RegisterAlertTypes()
		{
		}

		public AlertVisualType GetAlertVisualType(string alertTypeId)
		{
			return null;
		}

		public Alert_3DUIView CreateAlert(string alertTypeId, int number, string icon, Action<Alert_3DUIView> clickAction)
		{
			return null;
		}

		public void KillAlert(Alert_3DUIView alert)
		{
		}

		private float CalculateQueueLength()
		{
			return 0f;
		}

		public void RepositionAlerts()
		{
		}

		public void RegisterAlertType(AlertVisualType alertVisualType)
		{
		}
	}
}
