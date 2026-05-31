using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public class LocalizationRepaint : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private SoftReference<ILocaleRepaint> _objectToRepaint;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
			OnLocaleChanged(null);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
		}

		private void OnLocaleChanged(Locale obj)
		{
			_objectToRepaint.Value.RepaintLocale();
		}
	}
}
