using UnityEngine;

public class AsciiStringTest : MonoBehaviour, IAsciiObject
{
	public string stringToTest = "hello world!";

	public int posX;

	public int posY;

	private AsciiString asciiString = new AsciiString();

	private string lastString;

	private bool hasSet;

	private void Update()
	{
		if (lastString != stringToTest)
		{
			lastString = stringToTest;
			asciiString.SetValue(stringToTest);
		}
		if (!hasSet && GameStates.Singleton != null)
		{
			GameStates.Singleton.level.AddObject(this);
		}
	}

	public void UpdateTic()
	{
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += posX;
		offsetY += posY;
		asciiString.Draw(r, offsetX, offsetY);
	}
}
