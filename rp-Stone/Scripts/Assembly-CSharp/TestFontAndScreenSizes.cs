using UnityEngine;
using standardcombo;

public class TestFontAndScreenSizes
{
	private static string outputStr = "";

	private static string fonts = "Fonts:\n";

	public static void RunTest()
	{
		Test(480, 320, "Android HVGA");
		Test(800, 480, "Android WVGA800");
		Test(854, 480, "Android WVGA854");
		Test(1024, 600, "Android");
		Test(960, 640, "iPhone 4s, Android");
		Test(1136, 640, "iPhone 5");
		Test(1280, 720, "Youtube");
		Test(1334, 750, "iPhone 6");
		Test(1024, 768, "PC, iPad Mini, iPad2, Android");
		Test(1280, 768, "Android");
		Test(1366, 768, "PC");
		Test(1280, 800, "PC, Android WXGA");
		Test(1440, 900, "PC");
		Test(1600, 900, "PC");
		Test(1280, 1024, "PC");
		Test(1920, 1080, "PC, iPhone 6+");
		Test(1546, 1152, "Android");
		Test(1920, 1152, "Android");
		Test(1920, 1200, "Android");
		Test(2048, 1536, "iPad mini 2/3/4, iPad3, iPad Air/2, Android");
		Test(2560, 1536, "Android");
		Test(2560, 1600, "Android");
		Test(2732, 2048, "iPad Pro");
		Debug.Log(outputStr);
		Debug.Log(fonts);
	}

	private static void Test(int screenWidth, int screenHeight, string comment)
	{
		AsciiSizer.Result result = AsciiSizer.FindIdealSizes(screenWidth, screenHeight, 26, 25, 27, 92, 0.55172414f);
		outputStr = outputStr + $"{screenWidth}x{screenHeight}, {DetectAspectRatio(screenWidth, screenHeight)} ({comment})" + "\n" + $"{result.gridSize.width}x{result.gridSize.height} | {result.fontSize.width}x{result.fontSize.height} = {result.gridSize.width * result.fontSize.width}x{result.gridSize.height * result.fontSize.height} {FormatPadding(result.padding)}" + "\n\n";
		fonts += $"{result.fontSize.width}x{result.fontSize.height}\n";
	}

	private static string DetectAspectRatio(int screenWidth, int screenHeight)
	{
		int[] array = new int[26]
		{
			1, 1, 2, 3, 3, 4, 3, 5, 4, 5,
			5, 8, 9, 16, 3, 2, 4, 3, 5, 3,
			5, 4, 8, 5, 16, 9
		};
		for (int i = 0; i < array.Length; i += 2)
		{
			int testW = array[i];
			int testH = array[i + 1];
			if (RatioHelper(screenWidth, screenHeight, testW, testH))
			{
				return testW + ":" + testH;
			}
		}
		return screenWidth + ":" + screenHeight;
	}

	private static bool RatioHelper(int screenWidth, int screenHeight, int testW, int testH)
	{
		float num = (float)screenWidth / (float)screenHeight;
		float num2 = (float)testW / (float)testH;
		return Mathf.Abs(num - num2) < 0.01f;
	}

	private static string FormatPadding(AsciiSizer.Size padding)
	{
		int width = padding.width;
		int height = padding.height;
		string text = ((width > 0) ? "+" : "");
		text += width;
		string text2 = ((height > 0) ? "+" : "");
		text2 += height;
		return "(" + text + ", " + text2 + ")";
	}
}
