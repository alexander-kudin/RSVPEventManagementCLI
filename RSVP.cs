using System;
namespace ProjectFall2020
{
    class RSVP
    {
        int RSVPId;
        Customer customerRef;
        Event eventRef;
        string dateCreated;

        public RSVP(int RSVPId, Customer customerRef, Event eventRef)
        {
            this.RSVPId = RSVPId;
            this.customerRef = customerRef;
            this.eventRef = eventRef;
            this.dateCreated = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
        }

        public int getRSVPId() { return RSVPId; }
        public Customer getCustomerRef() { return customerRef; }
        public Event getEventRef() { return eventRef; }
        public string getRSVPCustomerFullName() { return customerRef.getFirstName() + " " + customerRef.getLastName(); }

        public override string ToString()
        {
            string s = "RSVP ID: " + RSVPId + " | Customer: " + getRSVPCustomerFullName() + " | Event ID: " + eventRef.getEventId() + " | Date Created: " + dateCreated.ToString();
            return s;
        }
    }
}

