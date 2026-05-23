using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Factory.FieldObject
{
	public class BillboardTextEffectCtrl : MonoBehaviour, ITemporaryBillboardCamera, IEventSystemHandler
	{
		private Transform _billboard;

		public TMP_Text textObject;

		private Vector3 _addPos;

		private float _duration;

		private Ease _ease;

		private Action finishAction;

		private bool play;

		private float _scale;

		private float _characterSpacing;

		private Transform parentCache;

		private void Awake()
		{
		}

		public void Init(string text, Vector3 addPos, float duration, Ease ease, Action finish = null, float scale = 1f, float characterSpacing = 0f)
		{
		}

		public void Play()
		{
		}

		private void Update()
		{
		}

		public void OnChangeCamera(Camera cm)
		{
		}
	}
}
