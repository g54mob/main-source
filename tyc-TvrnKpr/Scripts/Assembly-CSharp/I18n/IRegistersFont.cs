using Gh.Tk;
using UnityEngine;

namespace I18n
{
	public interface IRegistersFont
	{
		int FontIndex { get; }

		FontData GetOriginalFontData()
		{
			return null;
		}

		FontData GetFontData();

		void ReregisterFontWith(Material material);
	}
}
