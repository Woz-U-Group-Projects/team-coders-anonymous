namespace GroupProject3.Models {
    public class Resident {
        public int ID { get; private set;}
        public string AcctOwner { get; set; }
        public string UnitNum { get; set; }
        public string LastName1 { get; set; }
        public string FirstName1 { get; set; }
        public string StorageNum { get; set; }
        public string ContactNum1 { get; set; }
        public string ContactNum2 { get; set; }
        public string ContactNum3 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Email4 { get; set; }
        public string ParkingSpot1 { get; set; }
        public string ParkingSpot2 { get; set; }

        public string GetResidentRecord () {
            return "Account Number: " + this.ID + " Owner?: " + this.AcctOwner + " Unit Number: " + this.UnitNum + " Last Name: " + this.LastName1 + " First Name: " + this.FirstName1 + " Contact Phone Number 1: " + this.ContactNum1 + " Contact Phone Number 2: " + this.ContactNum2 + " Contact Phone Number 3: " + this.ContactNum3 + " Email 1: " + this.Email1 + " Email 2: " + this.Email2 + " Email 3: " + this.Email3 + " Email 4: " + this.Email4 + " Parking Spot(s): " + this.ParkingSpot1 + ", " + this.ParkingSpot2;
        }

    }
}