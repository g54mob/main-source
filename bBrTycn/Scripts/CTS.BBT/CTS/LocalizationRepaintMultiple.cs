using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public class LocalizationRepaintMultiple : CTSBehaviour
	{
		[InjectScope(EGetScope.Children)]
		[SerializeField]
		[Inject(false)]
		private SoftReference<ILocaleRepaint>[] _objectsToRepaint;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
		}

		private void OnLocaleChanged(Locale obj)
		{
			SoftReference<ILocaleRepaint>[] objectsToRepaint = _objectsToRepaint;
			foreach (SoftReference<ILocaleRepaint> softReference in objectsToRepaint)
			{
				ILocaleRepaint value = softReference.Value;
				if (!(value is Behaviour { isActiveAndEnabled: false }))
				{
					value.RepaintLocale();
				}
			}
		}
	}
}
