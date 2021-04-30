Feature: AudenShortTermLoan
	

Background: 
Given I have navigated to 'https://www.auden.co.uk/Credit/ShortTermLoan'

Scenario: Slider Amount is Loan amount
	When I select loan amount of £210
	Then Slider amount is the same as loan amount displayed

Scenario: Min and Max slider amount
Then The min loan amount is £200
And The max loan amount is £500

Scenario: Repayment date
When I select a payment date 23rd
Then the first repayment date will be Friday 21st May 2021

	