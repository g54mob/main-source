using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public sealed class OutputWidget : MonoBehaviour
{
	public Image Highlight;

	public Text Heading;

	public Text LeftValues;

	public Text RightValues;

	public Image[] ErrorHighlights;

	private _0023_003DqoZ_0024k6yAcVFoLTqCLaX3vcA_003D_003D _0023_003Dq5__00243jh8Sx2nWhOWWnlfVnPtI1KKBiwkKD2IdavDdTfM_003D;

	private static Action<Image> _0023_003Dq0pE4sQDSpyMX9obcb6TYhQ_003D_003D;

	public OutputWidget()
	{
		int num = 7;
		if (false)
		{
		}
		base._002Ector();
	}

	internal _0023_003DqoZ_0024k6yAcVFoLTqCLaX3vcA_003D_003D _0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()
	{
		int num = 0;
		if (2 == 0)
		{
		}
		return _0023_003Dq5__00243jh8Sx2nWhOWWnlfVnPtI1KKBiwkKD2IdavDdTfM_003D;
	}

	private void _0023_003DqMg9inv28chKMR6HZg2ZzvA_003D_003D(_0023_003DqoZ_0024k6yAcVFoLTqCLaX3vcA_003D_003D _0023_003DqyR_YP5AzzfHcqxFaJ2_Mww_003D_003D)
	{
		if (7u != 0)
		{
			_0023_003Dq5__00243jh8Sx2nWhOWWnlfVnPtI1KKBiwkKD2IdavDdTfM_003D = _0023_003DqyR_YP5AzzfHcqxFaJ2_Mww_003D_003D;
		}
	}

	public void Initialize(_0023_003DqoZ_0024k6yAcVFoLTqCLaX3vcA_003D_003D _0023_003DqPLhwOYEB6jfBhQ0y2JWa0A_003D_003D)
	{
		int num = 5;
		if (2 == 0)
		{
		}
		int num2 = 0;
		if (8 == 0)
		{
		}
		_0023_003DqMg9inv28chKMR6HZg2ZzvA_003D_003D(_0023_003DqPLhwOYEB6jfBhQ0y2JWa0A_003D_003D);
		int num3 = 7;
		if (7 == 0)
		{
		}
		Heading.text = _0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqOQ2xBjbdEOzpFMfAF5JFog_003D_003D;
		Refresh();
	}

	public void Refresh()
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2;
		if (true)
		{
			stringBuilder2 = stringBuilder;
		}
		int num = default(int);
		if (0 == 0)
		{
			num = 0;
		}
		while (num < _0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqWXfQk90_0024dllp3MA5GTVjT8_qYHhg_B0qvZWlgN9wY_4_003D().Length)
		{
			bool num2 = _0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqYVoqgDRN0tzc_JXN6_0024Icvg_003D_003D._0023_003DqnQSEwxLpbk8gGUwimtA4hg_003D_003D() && num == _0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqmLju5CA_0024hOhYjIdI9gfnz4w9zsx5FN9ODZmcv4QgnGM_003D().Count;
			bool flag;
			if (7u != 0)
			{
				flag = num2;
			}
			stringBuilder2.AppendFormat((!flag) ? _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991686) : _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991714), _0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqWXfQk90_0024dllp3MA5GTVjT8_qYHhg_B0qvZWlgN9wY_4_003D()[num]);
			int num3 = num + 1;
			if (2u != 0)
			{
				num = num3;
			}
		}
		LeftValues.text = stringBuilder2.ToString();
		if (_0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqYVoqgDRN0tzc_JXN6_0024Icvg_003D_003D._0023_003DqnQSEwxLpbk8gGUwimtA4hg_003D_003D() && _0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqmLju5CA_0024hOhYjIdI9gfnz4w9zsx5FN9ODZmcv4QgnGM_003D().Count < _0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqWXfQk90_0024dllp3MA5GTVjT8_qYHhg_B0qvZWlgN9wY_4_003D().Length)
		{
			Highlight.gameObject.SetActive(true);
			Highlight.rectTransform.anchoredPosition = new Vector2(0f, -12 * _0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqmLju5CA_0024hOhYjIdI9gfnz4w9zsx5FN9ODZmcv4QgnGM_003D().Count - 12);
		}
		else
		{
			Highlight.gameObject.SetActive(false);
		}
		StringBuilder stringBuilder3 = new StringBuilder();
		if (6u != 0)
		{
			stringBuilder2 = stringBuilder3;
		}
		Image[] errorHighlights = ErrorHighlights;
		if (_0023_003Dq0pE4sQDSpyMX9obcb6TYhQ_003D_003D == null)
		{
			_0023_003Dq0pE4sQDSpyMX9obcb6TYhQ_003D_003D = _0023_003DqKb1M_EVGeM8_rA2NyqYYMA_003D_003D;
		}
		errorHighlights._0023_003DqIovx0zgjiZWgUzRs7pO0pA_003D_003D(_0023_003Dq0pE4sQDSpyMX9obcb6TYhQ_003D_003D);
		for (int i = 0; i < _0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqWXfQk90_0024dllp3MA5GTVjT8_qYHhg_B0qvZWlgN9wY_4_003D().Length; i++)
		{
			if (_0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqmLju5CA_0024hOhYjIdI9gfnz4w9zsx5FN9ODZmcv4QgnGM_003D().Count > i)
			{
				bool flag2 = _0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqmLju5CA_0024hOhYjIdI9gfnz4w9zsx5FN9ODZmcv4QgnGM_003D()[i] == _0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqWXfQk90_0024dllp3MA5GTVjT8_qYHhg_B0qvZWlgN9wY_4_003D()[i];
				stringBuilder2.AppendFormat((!flag2) ? _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991714) : _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991686), _0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqmLju5CA_0024hOhYjIdI9gfnz4w9zsx5FN9ODZmcv4QgnGM_003D()[i]);
				ErrorHighlights[i].gameObject.SetActive(!flag2);
				ErrorHighlights[i].rectTransform.anchoredPosition = new Vector2(0f, -12 * i - 12);
			}
		}
		RightValues.text = stringBuilder2.ToString();
	}

	private static void _0023_003DqKb1M_EVGeM8_rA2NyqYYMA_003D_003D(Image _0023_003DqJRbpr3t0ILrRgULbdrV_Ig_003D_003D)
	{
		int num = -1;
		if (8 == 0)
		{
		}
		_0023_003DqJRbpr3t0ILrRgULbdrV_Ig_003D_003D.gameObject.SetActive(false);
	}
}
