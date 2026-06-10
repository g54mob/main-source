using UnityEngine;

public class STMDialogueSample : MonoBehaviour
{
	public SuperTextMesh textMesh;

	public KeyCode advanceKey = KeyCode.Return;

	public SpriteRenderer advanceKeySprite;

	private Vector3 advanceKeyStartScale = Vector3.one;

	public Vector3 advanceKeyScale = Vector3.one;

	public float advanceKeyTime = 1f;

	public string[] lines;

	private int currentLine;

	private void Start()
	{
		advanceKeyStartScale = advanceKeySprite.transform.localScale;
		Apply();
	}

	public void CompletedDrawing()
	{
		Debug.Log("I completed reading! Done!");
	}

	public void CompletedUnreading()
	{
		Debug.Log("I completed unreading!! Bye!");
		Apply();
	}

	private void Apply()
	{
		textMesh.Text = lines[currentLine];
		currentLine++;
		currentLine %= lines.Length;
	}

	private void Update()
	{
		if (Input.GetKey(advanceKey))
		{
			advanceKeySprite.transform.localScale = advanceKeyScale;
		}
		else
		{
			advanceKeySprite.transform.localScale = Vector3.Lerp(advanceKeySprite.transform.localScale, advanceKeyStartScale, Time.deltaTime * advanceKeyTime);
		}
		if (Input.GetKeyDown(advanceKey))
		{
			if (textMesh.reading)
			{
				textMesh.SpeedRead();
			}
			if (!textMesh.reading && !textMesh.unreading)
			{
				if (!textMesh.Continue())
				{
					textMesh.UnRead();
				}
				else
				{
					Debug.Log("CONTINUING NOW");
				}
			}
		}
		if (Input.GetKeyUp(advanceKey))
		{
			textMesh.RegularRead();
		}
	}
}
