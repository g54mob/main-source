using UnityEngine;

public class ResearchConnection : MonoBehaviour
{
	public ResearchNode n1;

	public ResearchNode n2;

	public LineRenderer lineRenderer;

	public bool isAvailable;

	public bool isInCorrectPath;

	public bool isRevealed;

	public bool isProposed;

	public bool isHighlighted;

	public bool isRuledOut;

	public ConnectionState displayedState;

	public void Reset()
	{
		isAvailable = false;
		isInCorrectPath = false;
		isRevealed = false;
		isHighlighted = false;
		displayedState = ConnectionState.None;
		isRuledOut = false;
	}

	public void UpdateDynamicDisplay()
	{
		if (isAvailable)
		{
			UpdatePosition();
		}
		lineRenderer.enabled = isAvailable && displayedState != ConnectionState.Rejected;
		switch (displayedState)
		{
		case ConnectionState.Confirmed:
			SetColor(Color.green);
			break;
		case ConnectionState.Unknown:
			SetColor(Color.gray);
			break;
		case ConnectionState.Highlighted:
			SetColor(Color.white);
			break;
		case ConnectionState.Rejected:
			SetColor(Color.red);
			break;
		case ConnectionState.Proposed:
			SetColor(Color.cyan);
			break;
		case ConnectionState.None:
			SetColor(Color.magenta);
			break;
		case ConnectionState.Unavailable:
			break;
		}
	}

	private void SetColor(Color c)
	{
		lineRenderer.startColor = c;
		lineRenderer.endColor = c;
	}

	public void CalcState()
	{
		if (isAvailable)
		{
			if (isRuledOut)
			{
				displayedState = ConnectionState.Rejected;
			}
			else if (isRevealed)
			{
				if (isInCorrectPath)
				{
					displayedState = ConnectionState.Confirmed;
				}
				else
				{
					displayedState = ConnectionState.Rejected;
				}
			}
			else if (isProposed)
			{
				displayedState = ConnectionState.Proposed;
			}
			else if (isHighlighted)
			{
				displayedState = ConnectionState.Highlighted;
			}
			else
			{
				displayedState = ConnectionState.Unknown;
			}
		}
		else
		{
			displayedState = ConnectionState.Unavailable;
		}
		base.gameObject.SetActive(isAvailable);
	}

	public void Reveal()
	{
		isRevealed = true;
		CalcState();
	}

	public void BecomeUnavailable()
	{
		isAvailable = false;
		CalcState();
	}

	public void RuleOut()
	{
		isRuledOut = true;
		CalcState();
	}

	public void UpdatePosition()
	{
		lineRenderer.alignment = LineAlignment.Local;
		lineRenderer.startWidth = 5f;
		lineRenderer.endWidth = 5f;
		base.transform.localPosition = Vector3.zero;
		Vector3 position = n1.transform.position;
		Vector3 position2 = n2.transform.position;
		Vector3 a = new Vector3(position.x, position.y, 0f);
		Vector3 b = new Vector3(position2.x, position2.y, 0f);
		float num = 0.75f;
		lineRenderer.SetPosition(0, Vector3.Lerp(a, b, 1f - num));
		lineRenderer.SetPosition(1, Vector3.Lerp(a, b, num));
	}

	public override string ToString()
	{
		return $"[Connection {n1} {n2} revealed:{isRevealed} path:{isInCorrectPath}]";
	}

	public bool IsEliminationCandidate()
	{
		if (isAvailable && !isRevealed)
		{
			return !isInCorrectPath;
		}
		return false;
	}
}
