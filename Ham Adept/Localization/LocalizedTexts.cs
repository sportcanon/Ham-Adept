using System.Linq;
using System.Reflection;
using System.Resources;

namespace HamAdept.Localization
{
    public class LocalizedTexts
    {
        #region Constructor

        const SupportedLanguage DefaultLanguage = SupportedLanguage.Czech;

        public LocalizedTexts(SupportedLanguage language = DefaultLanguage)
        {
            LocalizationResourceManager = new ResourceManager($"HamAdept.Localization.{language}", Assembly.GetExecutingAssembly());
        }

        #endregion	
        // properties
        #region @ LocalizationResourceManager

        private ResourceManager LocalizationResourceManager { get; }

        #endregion

        // methods
        #region GetLocalizedText

        public string GetLocalizedText(string localizationKey)
        {
            return LocalizationResourceManager.GetString(localizationKey);
        }

        public string GetLocalizedText(string localizationKey, params object[] parameters)
        {
            var localizedText = LocalizationResourceManager.GetString(localizationKey);
            var i = 1;
            return parameters.Aggregate(localizedText, (current, parameter) => current?.Replace($"[@{i++}]", parameter.ToString()));
        }

        #endregion
    }
}
