describe('Formy Components - Fill out and Test', () => {
  const baseUrl = 'https://formy-project.herokuapp.com/';

  beforeEach(() => {
    cy.clearCookies();
    cy.clearLocalStorage();
    cy.visit(baseUrl);
  });

  it('Test WebForm, Modal, Datepicker', () => {
    
    // Test 1: Complete Web Form
    cy.get('.navbar-nav').contains('Components').click();
    cy.contains('Complete Web Form').click();
    cy.url().should('include', '/form');
    
    cy.get('#first-name').type('Nimi'); 
    cy.get('#last-name').type('Name'); 
    cy.get('#job-title').type('Software Engineer'); 
    cy.get('#radio-button-1').check();
    cy.get('#checkbox-1').check(); 
    cy.get('#select-menu').select('1'); 
    
    cy.contains('Submit').click();
    cy.contains('The form was successfully submitted!').should('be.visible');

    // Go back to the homepage
    cy.get('#logo').click();
    
    // Test 2: Modal
    cy.get('.navbar-nav').contains('Components').click();
    cy.contains('Modal').click();
    cy.url().should('include', '/modal');
    cy.get('#modal-button').click({ force: true }); 
    cy.get('.modal-title').should('be.visible');
    cy.wait(500)
    cy.get('#close-button').click(); 
    
    
    // Test 3: Datepicker
    cy.get('.navbar-nav').contains('Components').click();
    cy.contains('Datepicker').click();
    cy.url().should('include', '/datepicker');
    cy.get('#datepicker').type('2022-02-12');
    cy.get('#datepicker').type('{enter}');

  });
});
