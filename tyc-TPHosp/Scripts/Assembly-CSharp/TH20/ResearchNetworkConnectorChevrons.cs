using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class ResearchNetworkConnectorChevrons : ResearchNetworkConnector
	{
		[SerializeField]
		private GameObject _chevronPrefab;

		[SerializeField]
		private float _chevronEndPointPadding;

		[SerializeField]
		private float _chevronPadding;

		[SerializeField]
		private float animationTime = 1f;

		[SerializeField]
		private float _maxGlow = 1.7f;

		[SerializeField]
		private AnimationCurveAsset _chevronFadeInCurve;

		[SerializeField]
		private AnimationCurveAsset _chevronGlowCurve;

		private const int MaxChevrons = 24;

		private readonly List<ResearchNetworkChevronItem> _chevronList = new List<ResearchNetworkChevronItem>();

		private Color _color;

		private bool _animate;

		private float _animationPosition;

		private Coroutine _activationCoroutine;

		public override void Setup(Vector3 startPosition, Vector3 endPosition)
		{
			base.Setup(startPosition, endPosition);
			InstantiateChevronList();
			SetAllChevronAlphas(1f);
			SetAllChevronGlow(0f);
		}

		public void Animate(bool animate = true)
		{
			if (_animate != animate)
			{
				_animate = animate;
				if (!_animate)
				{
					SetAllChevronAlphas(1f);
					SetAllChevronGlow(0f);
				}
			}
		}

		public void SetColor(Color color)
		{
			_color = color;
			for (int i = 0; i < _chevronList.Count; i++)
			{
				_chevronList[i].Color = _color;
			}
		}

		private void Update()
		{
			if (_animate)
			{
				UpdateChevronArcadeAnimation();
			}
		}

		private void UpdateChevronArcadeAnimation()
		{
			_animationPosition += Time.unscaledDeltaTime;
			if (_animationPosition >= animationTime)
			{
				_animationPosition -= animationTime;
			}
			float num = _animationPosition / animationTime;
			int count = _chevronList.Count;
			for (int i = 0; i < count; i++)
			{
				float num2 = Mathf.Clamp01(num * (float)count - (float)i);
				num2 = Mathf.PingPong(num2 * 2f, 1f);
				_chevronList[i].Glow = num2 * _maxGlow;
			}
		}

		private void InstantiateChevronList()
		{
			float num = Mathf.Max(Mathf.Abs(Vector3.Distance(StartPosition, EndPosition)) - _chevronEndPointPadding * 2f, 0f);
			int a = (int)(num / _chevronPadding);
			a = Mathf.Min(a, 24);
			float a2 = num - (float)(a - 1) * _chevronPadding;
			a2 = Mathf.Max(a2, 0f);
			if (a - _chevronList.Count > 0)
			{
				for (int i = _chevronList.Count; i < a; i++)
				{
					ResearchNetworkChevronItem component = Object.Instantiate(_chevronPrefab, base.transform).GetComponent<ResearchNetworkChevronItem>();
					_chevronList.Add(component);
				}
			}
			int num2 = _chevronList.Count - a;
			if (num2 > 0)
			{
				for (int j = a; j < _chevronList.Count; j++)
				{
					Object.Destroy(_chevronList[j].gameObject);
				}
				_chevronList.RemoveRange(a, num2);
			}
			Vector3 vector = EndPosition - StartPosition;
			vector.Normalize();
			float num3 = ((vector.y < 0f) ? Vector3.Angle(Vector3.left, vector) : (0f - Vector3.Angle(Vector3.left, vector)));
			num3 += 90f;
			for (int k = 0; k < _chevronList.Count; k++)
			{
				Vector3 localPosition = StartPosition + vector * (_chevronEndPointPadding + a2 * 0.5f + (float)k * _chevronPadding);
				_chevronList[k].transform.localPosition = localPosition;
				_chevronList[k].transform.rotation = Quaternion.Euler(0f, 0f, num3);
				_chevronList[k].Color = _color;
				_chevronList[k].Glow = 0f;
				_chevronList[k].ChevronAlpha = 0f;
			}
		}

		private void SetAllChevronAlphas(float alpha)
		{
			for (int i = 0; i < _chevronList.Count; i++)
			{
				_chevronList[i].ChevronAlpha = alpha;
			}
		}

		private void SetAllChevronGlow(float glow)
		{
			for (int i = 0; i < _chevronList.Count; i++)
			{
				_chevronList[i].Glow = glow;
			}
		}
	}
}
