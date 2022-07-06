using System;
namespace ProjectFall2020
{
    class EventCoordinator
    {
        CustomerManager custMan;
        EventManager eventMan;
        RSVPManager RSVPMan;
        

        public EventCoordinator(int custIdSeed, int maxCust, int eventIdSeed, int maxEvents, int RSVPIdSeed)
        {
            custMan = new CustomerManager(custIdSeed, maxCust);
            eventMan = new EventManager(eventIdSeed, maxEvents);
            RSVPMan = new RSVPManager(RSVPIdSeed);
        }

        // customer related methods.
        public bool addCustomer(string fname, string lname, string phone)
        {
            return custMan.addCustomer(fname, lname, phone);
        }

        public string customerList()
        {
            return custMan.getCustomerList();
        }

        public string getCustomerInfoById(int id)
        {
            return custMan.getCustomerInfo(id);
        }
        public bool deleteCustomer(int id)
        {
            if(custMan.customerExist(id))
            {
                RSVPMan.removeAllCustomerRSVP(id); // MODIFICATION (SERGEY PAVLOV) – removing all RSVPs asociated with the customer.
                eventMan.removeAllCustomerAttendees(id); // MODIFICATION (ALEKSANDR KUDIN) – removing all customer's attendees from events.
                custMan.deleteCustomer(id);
                return true;
            }
            return false;
        }

        // Event related methods.
        public bool addEvent(string name, string venue, Date eventDate, int maxAttendee)
        {
            return eventMan.addEvent(name, venue, eventDate, maxAttendee);
        }

        public string eventList()
        {
            return eventMan.getEventList();
        }

        public string getEventInfoById(int id)
        {
            return eventMan.getEventInfo(id);
        }

        // MODIFICATION (ALEKSANDR KUDIN) – IMPLEMENTED METHODS: makeRSVP().
        // MODIFICATION (MAKSIM KULIKOV) – IMPLEMENTED METHODS: viewRSVPs().
        // MODIFICATION (ALEKSANDR KUDIN) – IMPLEMENTED METHODS: eraseRSVP().

        public string makeRSVP(int eid, int cid)
        {
            if (!eventMan.eventExists(eid)) { return "There is no event with id " + eid + "."; } // event id check.
            if (!custMan.customerExist(cid)) { return "There is no customer with id " + cid + "."; } // customer id check.
            Customer c = custMan.getCustomer(cid); // puts customer reference in the variable.
            string customerFullName = custMan.getCustomer(cid).getFirstName() + " " + custMan.getCustomer(cid).getLastName(); // puts full name of the customer into the customerFullName variable.
            if (eventMan.isAlreadyRegistered(eid, cid)) { return customerFullName + " is already registered for the event with id " + eid + "."; } // duplicate check.
            if (!eventMan.addAtendee(eid, c)) { return "Event with id " + eid + " is full."; } // event space avaliability check -> register customer for the event.
            custMan.getCustomer(cid).incrementNumBooking(); // incrementing number of booking for the customer.
            RSVPMan.addRSVP(c, eventMan.getEvent(eid)); // add a record of RSVP to RSVP list.
            return customerFullName + " is registered for the event with id " + eid + "."; // display the successful message to the user
        }

        public string viewRSVPs()
        {
            return RSVPMan.getRSVPList();
        }

        public string eraseRSVP(int RSVPId)
        {
            if (!RSVPMan.RSVPExists(RSVPId)) { return "There is no RSVP with id " + RSVPId + "."; }
            RSVPMan.getRSVP(RSVPId).getCustomerRef().decrementNumBooking(); // decrement number of booking for the castomer which RSVP is deleted.
            RSVPMan.getRSVP(RSVPId).getEventRef().removeAttendee(RSVPMan.getRSVP(RSVPId).getCustomerRef().getId()); // Remove customer registration from the event.
            if (!RSVPMan.deleteRSVP(RSVPId)) { return "Error occured. This RSVP with ID " + RSVPId + " can not be deleted"; } // handling error. should not appear.
            return "RSVP with ID " + RSVPId + " has been deleted";
            

        }

    }

}
