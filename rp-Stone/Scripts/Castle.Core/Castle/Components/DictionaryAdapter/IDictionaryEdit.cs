using System;
using System.ComponentModel;

namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryEdit : IEditableObject, IRevertibleChangeTracking, IChangeTracking
	{
		bool CanEdit { get; }

		bool IsEditing { get; }

		bool SupportsMultiLevelEdit { get; set; }

		IDisposable SuppressEditingBlock();

		void SuppressEditing();

		void ResumeEditing();
	}
}
