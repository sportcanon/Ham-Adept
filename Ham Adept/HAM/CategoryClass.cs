using System.Collections.Generic;

namespace HamAdept.HAM
{
    public class CategoryClass
    {
        #region Constructor

        public CategoryClass()
        {

        }

        #endregion
        // properties
        #region @ CategoryClassId

        public int CategoryClassId { get; set; }

        #endregion
        #region @ CategoryClassName

        public string CategoryClassName { get; set; }

        #endregion
        // methods
        #region GetCategoryClasses

        public static List<CategoryClass> GetCategoryClasses()
        {
            return new List<CategoryClass>
            {
                new CategoryClass {CategoryClassId = 1, CategoryClassName = "Radiokomunika�n� p�edpisy"},
                new CategoryClass {CategoryClassId = 2, CategoryClassName = "Radiokomunika�n� provoz"},
                new CategoryClass {CategoryClassId = 3, CategoryClassName = "Elektrotechnika a radiotechnika"}
            };
        }

        #endregion
             
    }
}