using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Character.FacialExpression
{
	public class CharacterFacialAnimator : MonoBehaviour
	{
		private Dictionary<FaceBlendShape, float> _baseValues;

		[SerializeField]
		private SkinnedMeshRenderer _faceRenderer;

		private Dictionary<FaceBlendShape, List<FaceShape>> _faceShapeAffectors = new Dictionary<FaceBlendShape, List<FaceShape>>();

		[SerializeField]
		private List<FacialExpression> _facialExpressions;

		[SerializeField]
		private FacialExpression _neutralExpression;

		private Dictionary<FaceShape, FacialExpression> _shapeExpressionMap = new Dictionary<FaceShape, FacialExpression>();

		[SerializeField]
		private bool _updateShapes = true;

		public void RegisterExpression(FacialExpression expression)
		{
			if (!_facialExpressions.Contains(expression))
			{
				_facialExpressions.Add(expression);
				RegisterExpressionShapes(expression);
			}
		}

		public void SetBaseValues(SkinnedMeshRenderer faceRenderer, FacialExpression neutralExpression)
		{
			_faceRenderer = faceRenderer;
			_neutralExpression = neutralExpression;
			if (_baseValues == null)
			{
				_baseValues = new Dictionary<FaceBlendShape, float>();
			}
			else
			{
				_baseValues.Clear();
			}
			FaceShape[] faceShapes = neutralExpression.FaceShapes;
			foreach (FaceShape faceShape in faceShapes)
			{
				_baseValues[faceShape.BlendShape] = faceShape.Value;
				if (!_faceShapeAffectors.ContainsKey(faceShape.BlendShape))
				{
					_faceShapeAffectors.Add(faceShape.BlendShape, new List<FaceShape>());
				}
			}
		}

		public void UnregisterExpression(FacialExpression expression)
		{
			if (_facialExpressions.Contains(expression))
			{
				UnregisterExpressionShapes(expression);
				_facialExpressions.Remove(expression);
			}
		}

		protected void OnEnable()
		{
			if (_faceRenderer == null)
			{
				_faceRenderer = GetComponent<SkinnedMeshRenderer>();
			}
			SetBaseValues(_faceRenderer, _neutralExpression);
			foreach (FacialExpression facialExpression in _facialExpressions)
			{
				RegisterExpressionShapes(facialExpression);
			}
		}

		protected void Update()
		{
			if (!_updateShapes)
			{
				return;
			}
			foreach (KeyValuePair<FaceBlendShape, List<FaceShape>> faceShapeAffector in _faceShapeAffectors)
			{
				float value = 0f;
				_baseValues.TryGetValue(faceShapeAffector.Key, out value);
				float num = value;
				foreach (FaceShape item in faceShapeAffector.Value)
				{
					num += _shapeExpressionMap[item].Weight * ((float)item.Value - value);
				}
				_faceRenderer.SetBlendShapeWeight((int)faceShapeAffector.Key, Mathf.Clamp(Mathf.Round(num), 0f, 100f));
			}
		}

		private void RegisterBlendShape(FaceShape shape)
		{
			if (_faceShapeAffectors.TryGetValue(shape.BlendShape, out var value))
			{
				if (!value.Contains(shape))
				{
					value.Add(shape);
				}
			}
			else
			{
				_faceShapeAffectors.Add(shape.BlendShape, new List<FaceShape> { shape });
			}
		}

		private void RegisterExpressionShapes(FacialExpression expression)
		{
			FaceShape[] faceShapes = expression.FaceShapes;
			foreach (FaceShape faceShape in faceShapes)
			{
				RegisterBlendShape(faceShape);
				_shapeExpressionMap.TryAdd(faceShape, expression);
			}
		}

		private void UnregisterBlendShape(FaceShape shape)
		{
			if (_faceShapeAffectors.TryGetValue(shape.BlendShape, out var value))
			{
				if (value.Contains(shape))
				{
					value.Remove(shape);
				}
				if (_faceShapeAffectors[shape.BlendShape].Count == 0)
				{
					_faceShapeAffectors.Remove(shape.BlendShape);
				}
			}
		}

		private void UnregisterExpressionShapes(FacialExpression expression)
		{
			FaceShape[] faceShapes = expression.FaceShapes;
			foreach (FaceShape faceShape in faceShapes)
			{
				UnregisterBlendShape(faceShape);
				_shapeExpressionMap.Remove(faceShape);
			}
		}
	}
}
