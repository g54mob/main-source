using System;
using StatementParser;
using UnityEngine;
using UnityEngine.UI;

public class HintFocusPanel : Graphic
{
	public RectTransform Target;

	public RectTransform LabelRect;

	public CanvasGroup LabelGroup;

	public Text Label;

	public Texture Tex;

	public float Speed = 4f;

	public float CornerSize = 16f;

	[NonSerialized]
	public LineParse.TreeNode Completion;

	private float _timer;

	private Rect _lastPos;

	private static readonly Vector3[] _corners = new Vector3[4];

	public override Texture mainTexture
	{
		get
		{
			return Tex;
		}
	}

	private void Update()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		if (_timer < 2f)
		{
			_timer = Mathf.Min(2f, _timer + Time.deltaTime * Speed);
			LabelGroup.alpha = Mathf.Max(0f, _timer - 1f);
			SetVerticesDirty();
		}
		if (!Target.gameObject.activeSelf)
		{
			base.gameObject.SetActive(false);
			return;
		}
		if (Completion != null)
		{
			try
			{
				if ((bool)LineParse.Execute(Completion, ScriptSystem.TaskScope.Scope))
				{
					Completion = null;
					if (_timer >= 2f)
					{
						base.gameObject.SetActive(false);
						return;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Log(ex.ToString());
				Completion = null;
			}
		}
		else if (_timer >= 2f && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
		{
			base.gameObject.SetActive(false);
			return;
		}
		Rect screenCoords = GetScreenCoords(Target);
		if (screenCoords != _lastPos)
		{
			_lastPos = screenCoords;
			UpdateTextTransform();
			SetVerticesDirty();
		}
	}

	public void NewTarget(string target, string message, LineParse.TreeNode completion)
	{
		RectTransform rectTransform = WindowManager.FindElementPath(target);
		if (rectTransform == null)
		{
			Debug.Log("Couldn't find " + target + " for focus hint panel");
			base.gameObject.SetActive(false);
		}
		else
		{
			NewTarget(rectTransform, message, completion);
		}
	}

	public void NewTarget(RectTransform target, string message, LineParse.TreeNode completion)
	{
		if (!target.gameObject.activeSelf)
		{
			Debug.Log("Target " + target.name + " was not active for focus hint panel");
			base.gameObject.SetActive(false);
			return;
		}
		Target = target;
		Completion = completion;
		_timer = 0f;
		base.gameObject.SetActive(true);
		Label.text = message;
		LabelGroup.alpha = 0f;
		UpdateTextTransform();
	}

	private void UpdateTextTransform()
	{
		float num = (float)Screen.width / Options.UISize;
		float num2 = (float)Screen.height / Options.UISize;
		Rect screenCoords = GetScreenCoords(Target);
		screenCoords = new Rect(screenCoords.x - 6f, 0f - screenCoords.y + 6f, screenCoords.width + 12f, screenCoords.height + 12f);
		if (screenCoords.xMin > num - screenCoords.xMax)
		{
			float xMin = screenCoords.xMin;
			LabelRect.sizeDelta = new Vector2(Mathf.Min(256f, xMin), 0f);
			LabelRect.anchoredPosition = new Vector2(screenCoords.xMin - LabelRect.sizeDelta.x, 0f);
		}
		else
		{
			float b = num - screenCoords.xMax;
			LabelRect.sizeDelta = new Vector2(Mathf.Min(256f, b), 0f);
			LabelRect.anchoredPosition = new Vector2(screenCoords.xMax, 0f);
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(LabelRect);
		if (screenCoords.center.y < 0f)
		{
			LabelRect.pivot = new Vector2(0f, 1f);
			LabelRect.anchoredPosition = new Vector2(Mathf.Clamp(LabelRect.anchoredPosition.x, 0f, num - LabelRect.sizeDelta.x), Mathf.Clamp(screenCoords.yMin, 0f - num2 + LabelRect.sizeDelta.y, 0f));
		}
		else
		{
			LabelRect.pivot = new Vector2(0f, 0f);
			LabelRect.anchoredPosition = new Vector2(Mathf.Clamp(LabelRect.anchoredPosition.x, 0f, num - LabelRect.sizeDelta.x), Mathf.Clamp(screenCoords.yMin - screenCoords.height, 0f - num2, 0f - LabelRect.sizeDelta.y));
		}
	}

	private Rect GetScreenCoords(RectTransform target)
	{
		target.GetWorldCorners(_corners);
		for (int i = 0; i < 4; i++)
		{
			_corners[i] = base.transform.InverseTransformPoint(_corners[i]);
		}
		Rect rect = new Rect(_corners[1], _corners[3] - _corners[1]);
		return new Rect(rect.x, 0f - rect.y, rect.width, 0f - rect.height);
	}

	protected override void OnPopulateMesh(VertexHelper h)
	{
		h.Clear();
		if (Target != null)
		{
			Rect input = GetScreenCoords(Target);
			float num = (float)Screen.width / Options.UISize;
			float num2 = (float)Screen.height / Options.UISize;
			Vector2 uv = new Vector2(0f, 1f);
			if (Application.isPlaying)
			{
				float t = Mathf.Min(1f, _timer);
				input = input.Expand(8f, 8f);
				input = new Rect(Mathf.Lerp(0f, input.x, t), Mathf.Lerp(0f, input.y, t), Mathf.Lerp(num, input.width, t), Mathf.Lerp(num2, input.height, t));
			}
			h.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					position = new Vector3(input.xMin, 0f - input.yMin, 0f),
					color = color,
					uv0 = new Vector2(0f, 1f)
				},
				new UIVertex
				{
					position = new Vector3(input.xMin + CornerSize, 0f - input.yMin, 0f),
					color = color,
					uv0 = new Vector2(0f, 0f)
				},
				new UIVertex
				{
					position = new Vector3(input.xMin + CornerSize, 0f - input.yMin - CornerSize, 0f),
					color = color,
					uv0 = new Vector2(1f, 0f)
				},
				new UIVertex
				{
					position = new Vector3(input.xMin, 0f - input.yMin - CornerSize, 0f),
					color = color,
					uv0 = new Vector2(1f, 1f)
				}
			});
			h.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					position = new Vector3(input.xMin, 0f - input.yMax + CornerSize, 0f),
					color = color,
					uv0 = new Vector2(0f, 0f)
				},
				new UIVertex
				{
					position = new Vector3(input.xMin + CornerSize, 0f - input.yMax + CornerSize, 0f),
					color = color,
					uv0 = new Vector2(1f, 0f)
				},
				new UIVertex
				{
					position = new Vector3(input.xMin + CornerSize, 0f - input.yMax, 0f),
					color = color,
					uv0 = new Vector2(1f, 1f)
				},
				new UIVertex
				{
					position = new Vector3(input.xMin, 0f - input.yMax, 0f),
					color = color,
					uv0 = new Vector2(0f, 1f)
				}
			});
			h.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					position = new Vector3(input.xMax - CornerSize, 0f - input.yMin, 0f),
					color = color,
					uv0 = new Vector2(1f, 1f)
				},
				new UIVertex
				{
					position = new Vector3(input.xMax, 0f - input.yMin, 0f),
					color = color,
					uv0 = new Vector2(0f, 1f)
				},
				new UIVertex
				{
					position = new Vector3(input.xMax, 0f - input.yMin - CornerSize, 0f),
					color = color,
					uv0 = new Vector2(0f, 0f)
				},
				new UIVertex
				{
					position = new Vector3(input.xMax - CornerSize, 0f - input.yMin - CornerSize, 0f),
					color = color,
					uv0 = new Vector2(1f, 0f)
				}
			});
			h.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					position = new Vector3(input.xMax - CornerSize, 0f - input.yMax + CornerSize, 0f),
					color = color,
					uv0 = new Vector2(1f, 0f)
				},
				new UIVertex
				{
					position = new Vector3(input.xMax, 0f - input.yMax + CornerSize, 0f),
					color = color,
					uv0 = new Vector2(0f, 0f)
				},
				new UIVertex
				{
					position = new Vector3(input.xMax, 0f - input.yMax, 0f),
					color = color,
					uv0 = new Vector2(0f, 1f)
				},
				new UIVertex
				{
					position = new Vector3(input.xMax - CornerSize, 0f - input.yMax, 0f),
					color = color,
					uv0 = new Vector2(1f, 1f)
				}
			});
			if (input.x > 0f)
			{
				h.AddUIVertexQuad(new UIVertex[4]
				{
					new UIVertex
					{
						position = new Vector3(0f, 0f, 0f),
						color = color,
						uv0 = uv
					},
					new UIVertex
					{
						position = new Vector3(input.xMin, 0f, 0f),
						color = color,
						uv0 = uv
					},
					new UIVertex
					{
						position = new Vector3(input.xMin, 0f - num2, 0f),
						color = color,
						uv0 = uv
					},
					new UIVertex
					{
						position = new Vector3(0f, 0f - num2, 0f),
						color = color,
						uv0 = uv
					}
				});
			}
			if (input.x < num)
			{
				h.AddUIVertexQuad(new UIVertex[4]
				{
					new UIVertex
					{
						position = new Vector3(input.xMax, 0f, 0f),
						color = color,
						uv0 = uv
					},
					new UIVertex
					{
						position = new Vector3(num, 0f, 0f),
						color = color,
						uv0 = uv
					},
					new UIVertex
					{
						position = new Vector3(num, 0f - num2, 0f),
						color = color,
						uv0 = uv
					},
					new UIVertex
					{
						position = new Vector3(input.xMax, 0f - num2, 0f),
						color = color,
						uv0 = uv
					}
				});
			}
			if (input.y > 0f)
			{
				h.AddUIVertexQuad(new UIVertex[4]
				{
					new UIVertex
					{
						position = new Vector3(input.xMin, 0f, 0f),
						color = color,
						uv0 = uv
					},
					new UIVertex
					{
						position = new Vector3(input.xMax, 0f, 0f),
						color = color,
						uv0 = uv
					},
					new UIVertex
					{
						position = new Vector3(input.xMax, 0f - input.yMin, 0f),
						color = color,
						uv0 = uv
					},
					new UIVertex
					{
						position = new Vector3(input.xMin, 0f - input.yMin, 0f),
						color = color,
						uv0 = uv
					}
				});
			}
			if (input.y < num2)
			{
				h.AddUIVertexQuad(new UIVertex[4]
				{
					new UIVertex
					{
						position = new Vector3(input.xMin, 0f - input.yMax, 0f),
						color = color,
						uv0 = uv
					},
					new UIVertex
					{
						position = new Vector3(input.xMax, 0f - input.yMax, 0f),
						color = color,
						uv0 = uv
					},
					new UIVertex
					{
						position = new Vector3(input.xMax, 0f - num2, 0f),
						color = color,
						uv0 = uv
					},
					new UIVertex
					{
						position = new Vector3(input.xMin, 0f - num2, 0f),
						color = color,
						uv0 = uv
					}
				});
			}
		}
	}
}
