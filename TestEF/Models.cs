using System.Security.Cryptography;

namespace TestEF
{
    public abstract class EntityBase 
    {
        public Guid Id { get; protected set; }        
    }

    public class Place : EntityBase
    {
        private Place() { }

        public Place(Organization organization)
        {
            this.Id = organization.Id;
            this.Organization = organization;
        }

        public Place(Organization organization, Place parentPlace) : this(organization)
        {
            SetParentPlace(parentPlace);
        }

        public Place(Location location, Place parentPlace)
        {
            this.Id = location.Id;
            this.Location = location;

            SetParentPlace(parentPlace);
        }        

        public Guid? ParentId { get; private set; }
        public Place? Parent { get; private set; }

        public Guid? OrganizationId { get; private set; }
        public Organization? Organization { get; private set; }

        public Guid? LocationId { get; private set; }
        public Location? Location { get; private set; }        

        private void SetParentPlace(Place parentPlace)
        {
            Parent = parentPlace;            
        }        

        internal void MoveTo(Place parentePlace)
        {
            Parent = parentePlace;            
        }

        public override string ToString()
        {
            if (Organization is not null)
                return Organization.Name;

            if (Location is not null)
                return Location.Name;

            return string.Empty;
        }
    }

    public class Location : EntityBase
    {
        public Guid Id { get; private set; }

        public string Name { get; set; }

        public Place Place { get; set; }
    }

    public class Organization : EntityBase
    {
        public Guid Id { get; private set; }

        public string Name { get; set; }

        public Place Place { get; set; }
    }
}
