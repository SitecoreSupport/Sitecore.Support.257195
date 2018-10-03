namespace Sitecore.Support.Data.Fields
{
  using Sitecore.Data;
  using Sitecore.Data.Fields;
  using Sitecore.Data.Items;
  using Sitecore.Diagnostics;
  using Sitecore.Links;

  /// <summary>
  /// The reference field.
  /// </summary>
  public class ReferenceField : Sitecore.Data.Fields.ReferenceField
  {
    public ReferenceField(Field innerField) : base(innerField)
    {
    }

    public override void RemoveLink([NotNull] ItemLink itemLink)
    {
      Assert.ArgumentNotNull(itemLink, "itemLink");

      ID tempTargetID = (TargetID == ID.Null && ID.IsID(Path)) ? new ID(Path) : TargetID;

      if (itemLink.TargetItemID == tempTargetID)
      {
        this.Clear();
      }
    }
  }
}