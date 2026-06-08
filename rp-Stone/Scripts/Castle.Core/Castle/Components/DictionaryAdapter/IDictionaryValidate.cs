using System.Collections.Generic;
using System.ComponentModel;

namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryValidate : IDataErrorInfo
	{
		bool CanValidate { get; set; }

		bool IsValid { get; }

		IEnumerable<IDictionaryValidator> Validators { get; }

		DictionaryValidateGroup ValidateGroups(params object[] groups);

		void AddValidator(IDictionaryValidator validator);
	}
}
