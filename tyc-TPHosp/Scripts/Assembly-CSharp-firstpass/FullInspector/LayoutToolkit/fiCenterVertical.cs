using UnityEngine;

namespace FullInspector.LayoutToolkit
{
	public class fiCenterVertical : fiLayout
	{
		private string _id;

		private fiLayout _centered;

		public override float Height => _centered.Height;

		public fiCenterVertical(string id, fiLayout centered)
		{
			_id = id;
			_centered = centered;
		}

		public fiCenterVertical(fiLayout centered)
			: this(string.Empty, centered)
		{
		}

		public override bool RespondsTo(string sectionId)
		{
			if (!(_id == sectionId))
			{
				return _centered.RespondsTo(sectionId);
			}
			return true;
		}

		public override Rect GetSectionRect(string sectionId, Rect initial)
		{
			float num = initial.height - _centered.Height;
			initial.y += num / 2f;
			initial.height -= num;
			initial = _centered.GetSectionRect(sectionId, initial);
			return initial;
		}
	}
}
